using System;
using System.Data;

namespace Ringbuch
{
    public interface MaterialBearbeitenInterface
    {
        event EventHandler<StringEventArgs> MaterialByGruppeRequested;
        void SetJackenAll(DataTable dt);
        void SetKKAll(DataTable dt);
        void SetLGAll(DataTable dt);
        void SetHandschuheAll(DataTable dt);

        event EventHandler<DataTableEventArgs> MaterialInsertRequested;
        event EventHandler<DataTableEventArgs> MaterialUpdateRequested;

        event EventHandler MaterialDataTableRequested;
        void SetMaterialDataTable(DataTable dt);

        event EventHandler<IDEventArgs> MaterialDeleteRequested;
    }
}
